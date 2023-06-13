using RectangleLibrary1.IRectangleGetProperty;

namespace RectangleLibrary1
{
    public class RectangleServiceHelp : IRectangleServiceHelp
    {         
        public double[] UpdateArrayDelZero(double[] UpdateArray, double dotValue)
        {
            int zeroCount = 0;

            foreach (int element in UpdateArray)
            {
                if (element == 0)
                {
                    zeroCount++;
                }
            }

            if(zeroCount == UpdateArray.Length)
            {
                double[] updatedArrayMainCoord = new double[1];
                updatedArrayMainCoord[0] = dotValue;
                return updatedArrayMainCoord;
            }
            else
            { 
                double[] updatedArray = new double[UpdateArray.Length - zeroCount];
                int index = 0;

                // Копирование ненулевых элементов в новый массив
                foreach (int element in UpdateArray)
                {
                    if (element != 0)
                    {
                        updatedArray[index] = element;
                        index++;
                    }
                }

                return updatedArray;
            }
        }

    }
}