namespace Transport {
    interface IObsoleable {
        bool Relevant { get; }
        void ReduceRelevantTime(int months);
    }
}
