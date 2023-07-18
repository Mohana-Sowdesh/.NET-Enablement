class HelloWorld {
  static void Main() {
    Console.WriteLine("Enter the number: ");
    int usrInput = Convert.ToInt32(Console.ReadLine());

    int[,] resultArray = new int[3,3];

    resultArray[0,0] = 1;

    float divBy3Res = (float)usrInput/(float)3;
    int divBy3 = usrInput/3;
    divBy3Res = divBy3Res - divBy3;

    if(divBy3Res < 0.5)
        resultArray[0,1] = divBy3 - 1;
    else
        resultArray[0,1] = divBy3;

    resultArray[0,2] = usrInput - (resultArray[0,1] + resultArray[0,0]);

    for(int i=1; i<3; i++) {
        for(int j=0; j<3; j++) {
            resultArray[i,j] = resultArray[0,(i+j)%3];
        }
    }

    Console.WriteLine("The result is: ");
    for(int i=0; i<3; i++) {
        for(int j=0; j<3; j++) {
            Console.Write(resultArray[i,j]+ " ");
        }
        Console.WriteLine();
    }
  }
}
