// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

//using FestivalManager.Core.Controllers;
//using FestivalManager.Entities;
//using FestivalManager.Entities.Contracts;
//using FestivalManager.Entities.Sets;
//using FestivalManager.Entities.Instruments;

namespace FestivalManager.Tests
{
    using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void SetControllerShouldReturnException()
	    {
            IStage stage = new Stage();
            SetController setController = new SetController(stage);
            ISet set = new Short("set1");
            stage.AddSet(set);

            string actualResult = setController.PerformSets();
            string expectedResult = "1. set1:\r\n-- Did not perform";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void SetControllerShouldReturnSuccessMessage()
        {

            IStage stage = new Stage();
            SetController setController = new SetController(stage);
            ISet set = new Short("set1");
            stage.AddSet(set);

            IPerformer performer = new Performer("goshkata", 21);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            ISong song = new Song("ssong1", new System.TimeSpan(0, 2, 0));
            set.AddPerformer(performer);
            set.AddSong(song);

            string actualResult = setController.PerformSets();
            string expectedResult = "1. set1:\r\n-- 1. ssong1 (02:00)\r\n-- Set Successful";

            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }

        [Test]
        public void PerformSetsShouldDecreaseInstrumentsWear()
        {
            IStage stage = new Stage();
            SetController setController = new SetController(stage);
            ISet set = new Short("set1");
            stage.AddSet(set);

            IPerformer performer = new Performer("goshkata", 21);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            ISong song = new Song("ssong1", new System.TimeSpan(0, 2, 0));
            set.AddPerformer(performer);
            set.AddSong(song);

            setController.PerformSets();
            double actualWear = instrument.Wear;
            double expectedWear = 40;

            Assert.That(actualWear == expectedWear);
        }
    }
}