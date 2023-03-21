namespace Inventory;

class Object {
    float weight;
    public float Weight { get => weight;}
    float capacity;
    public float Capacity { get => capacity;}

    public Object(float weight, float capacity) {
        this.weight = weight;
        this.capacity = capacity;
    }

}