package com.company;
import java.util.Objects;
import java.util.Random;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Array Length: ");
        int arrLen = sc.nextInt();
        System.out.println("Number of threads: ");
        int threadsNum = sc.nextInt();

        MinClass minClass = new MinClass(arrLen);

        Thread[] threads = minClass.threadsMin(threadsNum);

        boolean notFinished = true;
        while (notFinished){
            for(Thread t : threads){
                if(!Objects.equals(t.getState().toString(), "TERMINATED")){
                    notFinished = true;
                    break;
                }
                notFinished = false;
            }
        }

        System.out.println("Result: nums[" + minClass.minIndex + "] = " + minClass.minValue );
    }
}