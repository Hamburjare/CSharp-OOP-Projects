namespace Inventory;

class Bag {
    float weight;
    public float Weight { get => weight; }
    float capacity;
    public float Capacity { get => capacity; }
    float currentWeight;
    public float CurrentWeight { get => currentWeight; }
    float currentCapacity;
    public float CurrentCapacity { get => currentCapacity; }
    int maxObjects;
    public int MaxObjects { get => maxObjects; }
    Object[] objects;
    public int ObjectCount { get => objects.Length; }

    public Bag(float weight, float capacity, int maxObjects) {
        this.weight = weight;
        this.capacity = capacity;
        this.currentWeight = 0;
        this.currentCapacity = 0;
        this.maxObjects = maxObjects;
        this.objects = new Object[0];
    }

    public bool AddObject(Object obj) {
        if (currentWeight + obj.Weight <= weight && currentCapacity + obj.Capacity <= capacity && objects.Length < maxObjects) {
            currentWeight += obj.Weight;
            currentCapacity += obj.Capacity;
            Object[] newObjects = new Object[objects.Length + 1];
            for (int i = 0; i < objects.Length; i++) {
                newObjects[i] = objects[i];
            }
            newObjects[objects.Length] = obj;
            objects = newObjects;
            return true;
        }
        return false;
    }

    public bool RemoveObject(Object obj) {
        if (objects.Length > 0) {
            for (int i = 0; i < objects.Length; i++) {
                if (objects[i] == obj) {
                    currentWeight -= obj.Weight;
                    currentCapacity -= obj.Capacity;
                    Object[] newObjects = new Object[objects.Length - 1];
                    for (int j = 0; j < i; j++) {
                        newObjects[j] = objects[j];
                    }
                    for (int j = i; j < newObjects.Length; j++) {
                        newObjects[j] = objects[j + 1];
                    }
                    objects = newObjects;
                    return true;
                }
            }
        }
        return false;
    }

    public override string ToString() {
        string result = $"Bag: {currentWeight}/{weight}kg, {currentCapacity}/{capacity}l, {objects.Length}/{maxObjects} Objects,  Objects:\n";
        for (int i = 0; i < objects.Length; i++) {
            if (objects[i] != null) {
                result += $"{objects[i].ToString()}\n";
            }
        }
        return result;
    }


}