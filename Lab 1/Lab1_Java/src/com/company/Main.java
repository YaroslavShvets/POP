package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter the number of threads:");
        int n = sc.nextInt();
        System.out.println("Enter step:");
        int step = sc.nextInt();
        sc.close();

        BreakThread breakThread = new BreakThread();

        for(int i = 0; i < n; i++){
            new MainThread(i, step, breakThread).start();
        }
        new Thread(breakThread).start();
    }
}
