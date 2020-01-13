namespace TrackerUI
{
    using TrackerLibrary.Models;

    public interface IPrizeRequester
    {
        void PrizeComplete(PrizeModel model);
    }
}
