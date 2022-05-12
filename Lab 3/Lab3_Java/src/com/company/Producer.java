package com.company;

import java.lang.*;

public class Producer implements Runnable{
    private final int fromId;
    private final int toId;
    private final Manager manager;

    public Producer(int fromId, int toId, Manager manager) {
        this.fromId = fromId;
        this.toId = toId;
        this.manager = manager;

        new Thread(this).start();
    }

    @Override
    public void run() {
        for (int i = fromId; i < toId; i++) {
            try {
                manager.full.acquire();
                manager.access.acquire();

                manager.storage.add("item " + i);
                System.out.println("Producer " + Thread.currentThread().getId() + " added item " + i);

                manager.access.release();
                manager.empty.release();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}