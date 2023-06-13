using RectangleLibrary1.IRectangleGetProperty;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.Models;
using Rectangles.ViewModels;
using System;

namespace RectangleLibrary1
{
    public class RectangleServiceChangingCoordinatesColorRec : IRectangleServiceChangingCoordinatesColorRec
    {
        private readonly IRectangleServiceHelp _rectangleServiceHelp;
        private readonly IRectangleService _rectangleService;

        public RectangleServiceChangingCoordinatesColorRec(IRectangleServiceHelp rectangleServiceHelp, 
                                                   IRectangleService rectangleService)
        {
            _rectangleServiceHelp = rectangleServiceHelp;
            _rectangleService = rectangleService;
        }

        public async Task<List<RectangleViewModel>> GetRectColorChangeCoordinateMethod(IRectangleRepository _rectangleRepo,
                                                                                       IPointRepository _pointRepo,
                                                                                       IColorBodyRepository _colorBodyRepo,
                                                                                       IColorLineRepository _colorLineRepo)
        {
            var allRectangles = await _rectangleService.GetAllRectanglesMethod(_rectangleRepo, _pointRepo, _colorBodyRepo, _colorLineRepo);

            double[] botLeftPointXmin = new double[allRectangles.Count()-1];
            double[] botLeftPointYmin = new double[allRectangles.Count() - 1];
            double[] topRightPointXmax = new double[allRectangles.Count() - 1];
            double[] topRightPointYmax = new double[allRectangles.Count() - 1];

            int k = 0;

            foreach (var item in allRectangles)
            {
                if(RectangleLibrary1.RectangleServiceConstants.RectangleColorBodyEqPink==item.ColorBodyRectangle && k < allRectangles.Count()-1)
                {
                    botLeftPointXmin[k] = item.BotLeftPointX;
                    botLeftPointYmin[k] = item.BotLeftPointY;
                    topRightPointXmax[k] = item.TopRightPointX;
                    topRightPointYmax[k] = item.TopRightPointY;
                }                
                k++;
            }

            var mainRectBotLeftX = 0.0;
            var mainRectBotRightY = 0.0;
            var mainRectTopRighttX = 0.0;
            var mainRectTopRighttY = 0.0;

            for (int i = allRectangles.Count() - 1; i < allRectangles.Count(); i++)
            {
                mainRectBotLeftX = allRectangles[i].BotLeftPointX;
                mainRectBotRightY = allRectangles[i].BotLeftPointY;
                mainRectTopRighttX = allRectangles[i].TopRightPointX;
                mainRectTopRighttY = allRectangles[i].TopRightPointY;
            }

            var botLeftPointXminArray = _rectangleServiceHelp.UpdateArrayDelZero(botLeftPointXmin, mainRectBotLeftX);
            var botLeftPointYminArray = _rectangleServiceHelp.UpdateArrayDelZero(botLeftPointYmin, mainRectBotRightY);
            var topRightPointXmaxArray = _rectangleServiceHelp.UpdateArrayDelZero(topRightPointXmax, mainRectTopRighttX);
            var topRightPointYmaxArray = _rectangleServiceHelp.UpdateArrayDelZero(topRightPointYmax, mainRectTopRighttY);

            var botLeftPointXminValue = botLeftPointXminArray.Min();
            var botLeftPointYminValue = botLeftPointYminArray.Min();
            var topRightPointXmaxValue = topRightPointXmaxArray.Max();
            var topRightPointYmaxValue = topRightPointYmaxArray.Max();

            for (int i = allRectangles.Count() - 1; i < allRectangles.Count(); i++)
            {
                allRectangles[i].BotLeftPointX = botLeftPointXminValue;
                allRectangles[i].BotLeftPointY = botLeftPointYminValue;
                allRectangles[i].TopRightPointX = topRightPointXmaxValue;
                allRectangles[i].TopRightPointY = topRightPointYmaxValue;
            }

            return allRectangles;
        }


        public async Task<List<RectangleViewModel>> GetRectColorPurpleTurquoiseMethod(IRectangleRepository _rectangleRepo,
                                                                                       IPointRepository _pointRepo,
                                                                                       IColorBodyRepository _colorBodyRepo,
                                                                                       IColorLineRepository _colorLineRepo)
        {
            var allRectangles = await _rectangleService.GetAllRectanglesMethod(_rectangleRepo, _pointRepo, _colorBodyRepo, _colorLineRepo);

            double[] botLeftPointXmin = new double[allRectangles.Count() - 1];
            double[] botLeftPointYmin = new double[allRectangles.Count() - 1];
            double[] topRightPointXmax = new double[allRectangles.Count() - 1];
            double[] topRightPointYmax = new double[allRectangles.Count() - 1];

            int k = 0;

            foreach (var item in allRectangles)
            {
                if ((RectangleLibrary1.RectangleServiceConstants.RectangleColorBodyEqTurquoise == item.ColorBodyRectangle &&
                    k < allRectangles.Count() - 1) || 
                    (RectangleLibrary1.RectangleServiceConstants.RectangleColorBodyEqPurple == item.ColorBodyRectangle &&
                    k < allRectangles.Count() - 1))
                {
                    botLeftPointXmin[k] = item.BotLeftPointX;
                    botLeftPointYmin[k] = item.BotLeftPointY;
                    topRightPointXmax[k] = item.TopRightPointX;
                    topRightPointYmax[k] = item.TopRightPointY;
                }
                k++;
            }

            var mainRectBotLeftX = 0.0;
            var mainRectBotRightY = 0.0;
            var mainRectTopRighttX = 0.0;
            var mainRectTopRighttY = 0.0;

            for (int i = allRectangles.Count() - 1; i < allRectangles.Count(); i++)
            {
                mainRectBotLeftX = allRectangles[i].BotLeftPointX;
                mainRectBotRightY = allRectangles[i].BotLeftPointY;
                mainRectTopRighttX = allRectangles[i].TopRightPointX;
                mainRectTopRighttY = allRectangles[i].TopRightPointY;
            }

            var botLeftPointXminArray = _rectangleServiceHelp.UpdateArrayDelZero(botLeftPointXmin, mainRectBotLeftX);
            var botLeftPointYminArray = _rectangleServiceHelp.UpdateArrayDelZero(botLeftPointYmin, mainRectBotRightY);
            var topRightPointXmaxArray = _rectangleServiceHelp.UpdateArrayDelZero(topRightPointXmax, mainRectTopRighttX);
            var topRightPointYmaxArray = _rectangleServiceHelp.UpdateArrayDelZero(topRightPointYmax, mainRectTopRighttY);

            var botLeftPointXminValue = botLeftPointXminArray.Min();
            var botLeftPointYminValue = botLeftPointYminArray.Min();
            var topRightPointXmaxValue = topRightPointXmaxArray.Max();
            var topRightPointYmaxValue = topRightPointYmaxArray.Max();

            for (int i = allRectangles.Count() - 1; i < allRectangles.Count(); i++)
            {
                allRectangles[i].BotLeftPointX = botLeftPointXminValue;
                allRectangles[i].BotLeftPointY = botLeftPointYminValue;
                allRectangles[i].TopRightPointX = topRightPointXmaxValue;
                allRectangles[i].TopRightPointY = topRightPointYmaxValue;
            }

            return allRectangles;
        }
    }
}