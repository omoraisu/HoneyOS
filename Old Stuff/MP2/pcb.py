class PCB:
    def __init__(self, pID, arrival_time, burst_time, priority):
        self.pID = pID
        self.arrival_time = arrival_time
        self.burst_time = burst_time
        self.priority = priority
        self.waiting_time = 0
        self.turnaround_time = 0


