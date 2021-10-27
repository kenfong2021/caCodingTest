using C4.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace caCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            double diff = 9999;
            string sizeName = "";
            string Filepath = Directory.GetCurrentDirectory() + "/Sample Images";

            string SelectedFile = "";

            //Show available files for user input
            while (string.IsNullOrEmpty(SelectedFile) || !File.Exists(SelectedFile))
            {
                
                
                foreach (var path in Directory.GetFiles(Filepath))
                {
                    Console.WriteLine(Path.GetFileName(path));
                    
                }
                Console.WriteLine("Choose 1 file name with extension above:");
                SelectedFile = Console.ReadLine();
                SelectedFile = Filepath + "/" + SelectedFile;

            }
            
            


            ImageAnalyser imageAnalyser = new ImageAnalyser();
            Size size = imageAnalyser.GetImageSize(SelectedFile); //Calculate the Size (width,Height) of the image 
  
            AspectRatio aspectRatio = new AspectRatio("NIL", size.Width, size.Height);
            AspectRatioRepository aspectRatioRepository = new AspectRatioRepository();
            var repositoryList = (List<AspectRatio>)aspectRatioRepository.All; //Retrieve the Predefined Ratio list

            
            foreach (AspectRatio aspectRatio1 in repositoryList)
            {
                //Iterate all the Ratio in the list, calcute the Quotient difference between the predefined ratio and the chose one' ratio
                if (diff > Math.Abs(aspectRatio1.Quotient - aspectRatio.Quotient))
                {
                    diff = Math.Abs(aspectRatio1.Quotient - aspectRatio.Quotient);
                    sizeName = aspectRatio1.Description;
                }
            }

            // Output the result
            Console.WriteLine("The aspect-ratio of the file is " + sizeName);

        }
    }
    }

