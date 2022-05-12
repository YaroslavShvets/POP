package com.company;

import java.lang.*;
import java.util.ArrayList;
import java.util.concurrent.Semaphore;

public class Manager {

    public Semaphore access;
    public Semaphore full;
    public Semaphore empty;

    public ArrayList<String> storage = new ArrayList<String>();

    public Manager(int storageSize) {
        access = new Semaphore(1);
        full = new Semaphore(storageSize);
        empty = new Semaphore(0);
    }
}