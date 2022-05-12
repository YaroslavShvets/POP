package com.company;

import java.lang.*;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter storage size: ");
        int storageSize = sc.nextInt();
        System.out.println("Enter itemNumbers: ");
        int itemNumbers = sc.nextInt();

        Main main = new Main();

        sc.close();

        main.starter(storageSize, itemNumbers, 2, 5);
    }
    private void starter(int storageSize, int itemNumbers, int producers, int consumers) {
        Manager manager = new Manager(storageSize);

        for(int i = 0; i < producers; i++) {
            new Producer(i * itemNumbers / producers, (i + 1) * itemNumbers / producers, manager);
        }

        for(int i = 0; i < consumers; i++) {
            new Consumer((i + 1) * itemNumbers / consumers - i * itemNumbers / consumers, manager);
        }
    }
}