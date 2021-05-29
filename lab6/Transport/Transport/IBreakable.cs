namespace Transport {
    interface IBreakable {
        string Condition { get; set; }
        string Destroy();
        string Repair();

    }
}
