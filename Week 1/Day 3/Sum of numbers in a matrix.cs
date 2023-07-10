using System;

class HelloWorld {
  static void Main() {
    Console.WriteLine("Enter the number: ");
    int usr_input = Convert.ToInt32(Console.ReadLine());

    int[,] result_arr = new int[3,3];

    result_arr[0,0] = 1;

    float div_by_3_res = (float)usr_input/3;
    int div_by_3 = usr_input/3;
    div_by_3_res = div_by_3_res - div_by_3;

    if(div_by_3_res < 0.5)
        result_arr[0,1] = div_by_3-1;
    else
        result_arr[0,1] = div_by_3;

    result_arr[0,2] = usr_input - (result_arr[0,1]+result_arr[0,0]);

    for(int i=1; i<3; i++) {
        for(int j=0; j<3; j++) {
            result_arr[i,j] = result_arr[0,(i+j)%3];
        }
    }

    Console.WriteLine("The result is: ");
    for(int i=0; i<3; i++) {
        for(int j=0; j<3; j++) {
            Console.Write(result_arr[i,j]+ " ");
        }
        Console.WriteLine();
    }
  }
}
