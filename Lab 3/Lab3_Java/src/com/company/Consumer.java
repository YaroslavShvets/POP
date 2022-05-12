package com.company;

import java.lang.*;

public class Consumer implements Runnable{
    private final int itemCount;
    private final Manager manager;

    public Consumer(int itemCount, Manager manager) {
        this.itemCount = itemCount;
        this.manager = manager;

        new Thread(this).start();
    }

    @Override
    public void run() {
        for (int i = 0; i < itemCount; i++) {
            String item;
            try {
                manager.empty.acquire();
                Thread.sleep(10);
                manager.access.acquire();

                item = manager.storage.get(0);
                manager.storage.remove(0);
                System.out.println("Consumer " + Thread.currentThread().getId() + " took " + item);

                manager.access.release();
                manager.full.release();

            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}