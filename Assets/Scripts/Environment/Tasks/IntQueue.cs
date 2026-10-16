using System;
using System.Collections.Generic;

public class IntQueue {
    private List<int> myQueue = new List<int>();

    public int count() {
        return myQueue.Count;
    }

    public bool isEmpty() {
        return myQueue.Count == 0;
    }

    public void enqueue(int newElement) {
        myQueue.Add(newElement);
    }

    public int dequeue() {
        if(isEmpty()) {
            throw new Exception("Queue is empty");
        }

        int firstElement = myQueue[0];
        myQueue.RemoveAt(0);

        return firstElement;
    }

    public int peek() {
        if(isEmpty()) {
            throw new Exception("Queue is empty");
        }

        return myQueue[0];
    }

    public void clear() {
        myQueue.Clear();
    }
}
