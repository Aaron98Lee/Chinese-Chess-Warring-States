using NUnit.Framework;
using Xiangqi.Core;

namespace Xiangqi.Core.Tests
{
    /// <summary>
    /// One positive and one or more negative cases for every Xiangqi movement rule, each asserting the
    /// specific illegal-move reason (acceptance criterion QG-02). Each test position is a valid
    /// position described in its comment; ranks in FEN run from rank 9 (Black's back rank) to rank 0.
    /// </summary>
    [TestFixture]
    public class RuleTests
    {
        private static MoveCheck Check(string fen, string move) => Position.FromFen(fen).Check(Move.Parse(move));

        private static void AssertLegal(string fen, string move)
        {
            var result = Check(fen, move);
            Assert.That(result.IsLegal, Is.True, $"{move} should be legal in {fen}, but was {result}");
            Assert.That(Position.FromFen(fen).LegalMoves(), Does.Contain(Move.Parse(move)));
        }

        private static void AssertIllegal(string fen, string move, IllegalReason reason, string? related = null)
        {
            var result = Check(fen, move);
            Assert.That(result.IsLegal, Is.False, $"{move} should be illegal in {fen}");
            Assert.That(result.Reason, Is.EqualTo(reason), $"{move} in {fen}");
            if (related != null)
            {
                Assert.That(result.RelatedSquare, Is.EqualTo(Square.Parse(related)), $"related square for {move}");
            }

            Assert.That(Position.FromFen(fen).LegalMoves(), Does.Not.Contain(Move.Parse(move)));
        }

        // ---------------------------------------------------------------- General

        // Red General d0, Black General e9, nothing else.
        private const string LoneGenerals = "4k4/9/9/9/9/9/9/9/9/3K5 w - - 0 1";

        [Test]
        public void General_MovesOnePointOrthogonallyInsidePalace() => AssertLegal(LoneGenerals, "d0d1");

        [Test]
        public void General_CannotLeavePalace() => AssertIllegal(LoneGenerals, "d0c0", IllegalReason.PalaceRestriction);

        [Test]
        public void General_CannotMoveDiagonallyOrTwoPoints()
        {
            AssertIllegal(LoneGenerals, "d0e1", IllegalReason.InvalidMovePattern);
            AssertIllegal(LoneGenerals, "d0d2", IllegalReason.InvalidMovePattern);
        }

        [Test]
        public void General_CannotStepOntoOpenFileFacingEnemyGeneral() =>
            AssertIllegal(LoneGenerals, "d0e0", IllegalReason.FlyingGeneral, "e9");

        // ---------------------------------------------------------------- Advisor

        // Red Advisor d0, Red General e0, Black General d9.
        private const string AdvisorPosition = "3k5/9/9/9/9/9/9/9/9/3AK4 w - - 0 1";

        [Test]
        public void Advisor_MovesOnePointDiagonallyInsidePalace() => AssertLegal(AdvisorPosition, "d0e1");

        [Test]
        public void Advisor_CannotLeavePalace() => AssertIllegal(AdvisorPosition, "d0c1", IllegalReason.PalaceRestriction);

        [Test]
        public void Advisor_CannotMoveOrthogonally() => AssertIllegal(AdvisorPosition, "d0d1", IllegalReason.InvalidMovePattern);

        // ---------------------------------------------------------------- Elephant

        // Red Elephant c4, Red Horse d3 (blocks the c4–e2 eye), Red General e0, Black General d9.
        private const string ElephantPosition = "3k5/9/9/9/9/2B6/3N5/9/9/4K4 w - - 0 1";

        [Test]
        public void Elephant_MovesExactlyTwoPointsDiagonally() => AssertLegal(ElephantPosition, "c4a2");

        [Test]
        public void Elephant_CannotCrossTheRiver()
        {
            AssertIllegal(ElephantPosition, "c4a6", IllegalReason.RiverRestriction);
            AssertIllegal(ElephantPosition, "c4e6", IllegalReason.RiverRestriction);
        }

        [Test]
        public void Elephant_IsBlockedByOccupiedEye() =>
            AssertIllegal(ElephantPosition, "c4e2", IllegalReason.ElephantEyeBlocked, "d3");

        [Test]
        public void Elephant_CannotMoveOnePointOrOrthogonally()
        {
            AssertIllegal(ElephantPosition, "c4b3", IllegalReason.InvalidMovePattern);
            AssertIllegal(ElephantPosition, "c4c2", IllegalReason.InvalidMovePattern);
        }

        // ---------------------------------------------------------------- Horse

        // Red Horse b0, Red Chariot b1 (blocks the b1 leg), Red General e0, Black General d9.
        private const string HorsePosition = "3k5/9/9/9/9/9/9/9/1R7/1N2K4 w - - 0 1";

        [Test]
        public void Horse_MovesOneOrthogonalThenOneDiagonal() => AssertLegal(HorsePosition, "b0d1");

        [Test]
        public void Horse_IsBlockedByOccupiedLeg()
        {
            AssertIllegal(HorsePosition, "b0a2", IllegalReason.HorseLegBlocked, "b1");
            AssertIllegal(HorsePosition, "b0c2", IllegalReason.HorseLegBlocked, "b1");
        }

        [Test]
        public void Horse_CannotMoveInOtherShapes() => AssertIllegal(HorsePosition, "b0b2", IllegalReason.InvalidMovePattern);

        // ---------------------------------------------------------------- Chariot

        // Red Chariot a0, Red Horse c0, Red General e0, Black General d9.
        private const string ChariotPosition = "3k5/9/9/9/9/9/9/9/9/R1N1K4 w - - 0 1";

        [Test]
        public void Chariot_MovesAnyDistanceOrthogonally()
        {
            AssertLegal(ChariotPosition, "a0b0");
            AssertLegal(ChariotPosition, "a0a9");
        }

        [Test]
        public void Chariot_CannotPassThroughPieces() =>
            AssertIllegal(ChariotPosition, "a0d0", IllegalReason.PathObstructed, "c0");

        [Test]
        public void Chariot_CannotMoveDiagonally() => AssertIllegal(ChariotPosition, "a0b1", IllegalReason.InvalidMovePattern);

        // ---------------------------------------------------------------- Cannon

        // Red Cannon a0, Red Horse c0 (screen), Black Chariot e0, Black Horse a5, Red General f1, Black General d9.
        private const string CannonPosition = "3k5/9/9/9/n8/9/9/9/5K3/C1N1r4 w - - 0 1";

        // As above but with a second screen on b0.
        private const string CannonTwoScreens = "3k5/9/9/9/9/9/9/9/5K3/CNN1r4 w - - 0 1";

        [Test]
        public void Cannon_MovesLikeChariotWhenNotCapturing() => AssertLegal(CannonPosition, "a0b0");

        [Test]
        public void Cannon_CapturesByJumpingExactlyOneScreen() => AssertLegal(CannonPosition, "a0e0");

        [Test]
        public void Cannon_CannotPassThroughPiecesWithoutCapturing() =>
            AssertIllegal(CannonPosition, "a0d0", IllegalReason.PathObstructed, "c0");

        [Test]
        public void Cannon_CannotCaptureWithoutScreen() =>
            AssertIllegal(CannonPosition, "a0a5", IllegalReason.CannonNeedsOneScreen);

        [Test]
        public void Cannon_CannotCaptureOverTwoScreens() =>
            AssertIllegal(CannonTwoScreens, "a0e0", IllegalReason.CannonNeedsOneScreen, "c0");

        // ---------------------------------------------------------------- Soldier

        // Red Soldier e3 (not yet across the river), Red General e0, Black General d9.
        private const string RedSoldierBeforeRiver = "3k5/9/9/9/9/9/4P4/9/9/4K4 w - - 0 1";

        // Red Soldier e5 (across the river).
        private const string RedSoldierAfterRiver = "3k5/9/9/9/4P4/9/9/9/9/4K4 w - - 0 1";

        // Black Soldier e6 (not yet across), Black to move, Red General e0, Black General d9.
        private const string BlackSoldierBeforeRiver = "3k5/9/9/4p4/9/9/9/9/9/4K4 b - - 0 1";

        [Test]
        public void Soldier_MovesForwardBeforeRiver() => AssertLegal(RedSoldierBeforeRiver, "e3e4");

        [Test]
        public void Soldier_CannotMoveSidewaysBeforeRiver() =>
            AssertIllegal(RedSoldierBeforeRiver, "e3d3", IllegalReason.SoldierSidewaysBeforeRiver);

        [Test]
        public void Soldier_NeverMovesBackward()
        {
            AssertIllegal(RedSoldierBeforeRiver, "e3e2", IllegalReason.SoldierCannotMoveThatWay);
            AssertIllegal(RedSoldierAfterRiver, "e5e4", IllegalReason.SoldierCannotMoveThatWay);
        }

        [Test]
        public void Soldier_MovesForwardOrSidewaysAfterRiver()
        {
            AssertLegal(RedSoldierAfterRiver, "e5e6");
            AssertLegal(RedSoldierAfterRiver, "e5d5");
            AssertLegal(RedSoldierAfterRiver, "e5f5");
        }

        [Test]
        public void Soldier_CannotMoveDiagonally() =>
            AssertIllegal(RedSoldierAfterRiver, "e5d6", IllegalReason.SoldierCannotMoveThatWay);

        [Test]
        public void BlackSoldier_MovesTowardRedSide()
        {
            AssertLegal(BlackSoldierBeforeRiver, "e6e5");
            AssertIllegal(BlackSoldierBeforeRiver, "e6e7", IllegalReason.SoldierCannotMoveThatWay);
            AssertIllegal(BlackSoldierBeforeRiver, "e6d6", IllegalReason.SoldierSidewaysBeforeRiver);
        }

        // ---------------------------------------------------------------- general legality

        [Test]
        public void Move_FromEmptySquareIsRejected() =>
            AssertIllegal(Position.InitialFen, "e4e5", IllegalReason.NoPieceAtSource, "e4");

        [Test]
        public void Move_OfOpponentPieceIsRejected() =>
            AssertIllegal(Position.InitialFen, "h7e7", IllegalReason.NotYourPiece, "h7");

        [Test]
        public void Move_OntoOwnPieceIsRejected() =>
            AssertIllegal(Position.InitialFen, "a0a3", IllegalReason.OwnPieceAtTarget, "a3");

        // Red Chariot e1 pinned against Red General e0 by Black Chariot e8; Black General d9.
        private const string PinnedChariot = "3k5/4r4/9/9/9/9/9/9/4R4/4K4 w - - 0 1";

        [Test]
        public void Move_ThatLeavesOwnGeneralInCheckIsRejected() =>
            AssertIllegal(PinnedChariot, "e1d1", IllegalReason.LeavesGeneralInCheck, "e8");

        [Test]
        public void PinnedPiece_MayMoveAlongThePinLine()
        {
            AssertLegal(PinnedChariot, "e1e5");
            AssertLegal(PinnedChariot, "e1e8");
        }

        // Red Horse e4 is the only piece between the Generals on the e-file.
        private const string HorseScreensGenerals = "4k4/9/9/9/9/4N4/9/9/9/4K4 w - - 0 1";

        [Test]
        public void Move_ThatExposesFacingGeneralsIsRejected()
        {
            AssertIllegal(HorseScreensGenerals, "e4d6", IllegalReason.FlyingGeneral, "e9");
            AssertIllegal(HorseScreensGenerals, "e4c3", IllegalReason.FlyingGeneral, "e9");
            AssertLegal(HorseScreensGenerals, "e0e1");
            Assert.That(Position.FromFen(HorseScreensGenerals).LegalMovesFrom(Square.Parse("e4")), Is.Empty);
        }

        // ---------------------------------------------------------------- check, mate, stalemate

        [Test]
        public void Check_ByCannonOverExactlyOneScreen()
        {
            // Red Cannon e1, Black Soldier e4 as screen, Black General e9; Black to move.
            var p = Position.FromFen("4k4/9/9/9/9/4p4/9/9/4C4/3K5 b - - 0 1");
            Assert.That(p.IsInCheck(), Is.True);
            Assert.That(p.FindCheckingPiece(Side.Black), Is.EqualTo(Square.Parse("e1")));
        }

        [Test]
        public void Check_ByHorseOnlyWhenLegIsFree()
        {
            // Red Horse d7 attacks e9 through the d8 leg.
            Assert.That(Position.FromFen("4k4/9/3N5/9/9/9/9/9/9/3K5 b - - 0 1").IsInCheck(), Is.True);

            // Same position with a Black Horse on d8 blocking the leg: no check.
            Assert.That(Position.FromFen("4k4/3n5/3N5/9/9/9/9/9/9/3K5 b - - 0 1").IsInCheck(), Is.False);
        }

        [Test]
        public void Checkmate_SideToMoveLoses()
        {
            // Red Soldier e8 checks the Black General e9; Black Horses on d9 and f9 block its escape,
            // and capturing the Soldier would leave the Generals facing on the open e-file.
            var p = Position.FromFen("3nkn3/4P4/9/9/9/9/9/9/9/4K4 b - - 0 1");
            Assert.That(p.IsInCheck(), Is.True);
            Assert.That(p.LegalMoves(), Is.Empty);
            Assert.That(p.Status(), Is.EqualTo(PositionStatus.Checkmate));
            Assert.That(p.Winner(), Is.EqualTo(Side.Red));
        }

        [Test]
        public void Stalemate_SideToMoveLoses_NotADraw()
        {
            // Black General d9 is not in check, but d8 is covered by the Red Chariot on a8 and e9 would
            // face the Red General on the open e-file: Black has no legal move and therefore loses.
            var p = Position.FromFen("3k5/R8/9/9/9/9/9/9/9/4K4 b - - 0 1");
            Assert.That(p.IsInCheck(), Is.False);
            Assert.That(p.LegalMoves(), Is.Empty);
            Assert.That(p.Status(), Is.EqualTo(PositionStatus.Stalemate));
            Assert.That(p.Winner(), Is.EqualTo(Side.Red));
        }

        [Test]
        public void InitialPosition_IsOngoingWithNoWinner()
        {
            var p = Position.Initial();
            Assert.That(p.Status(), Is.EqualTo(PositionStatus.Ongoing));
            Assert.That(p.Winner(), Is.Null);
            Assert.That(p.IsInCheck(), Is.False);
        }
    }
}
