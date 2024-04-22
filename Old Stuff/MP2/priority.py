class PCB:
    def __init__(self, pID, arrival, burst_time, priority):
        self.pID = pID
        self.arrival = arrival
        self.burst_time = burst_time
        self.priority = priority
        self.waiting_time = 0
        self.turnaround_time = 0
    
    def __str__(self):
        return f"Process: {self.pID} | Waiting Time: {self.waiting_time} | Turnaround Time: {self.turnaround_time}"


class Scheduler:
    def __init__(self, processes):
        self.processes = processes
        self.current_time = 0
        self.completed_processes = []
    
    def run(self):
        self.processes.sort(key=lambda p: (p.priority, p.pID))
        while self.processes:
            executing_process = self.processes.pop(0)
            executing_process.waiting_time = self.current_time
            executing_process.turnaround_time = executing_process.waiting_time + executing_process.burst_time
            self.current_time += executing_process.burst_time
            self.completed_processes.append(executing_process)

        for p in self.completed_processes:
            print(p)

    def get_avg_waiting_time(self):
        total_waiting_time = sum([p.waiting_time for p in self.completed_processes])
        return total_waiting_time / len(self.completed_processes)

    def get_avg_turnaround_time(self):
        total_turnaround_time = sum([p.turnaround_time for p in self.completed_processes])
        return total_turnaround_time / len(self.completed_processes)

    def print_gantt_chart(self):
        print("Gantt chart:")
        for p in self.completed_processes:
            print("P" + str(p.pID), end="")
            for i in range(p.burst_time):
                print("-", end="")
            print(" ", end="")
        print()

with open("process2.txt") as f:
    lines = f.readlines()[1:] # Skip header line
    processes = [PCB(*[int(x) for x in line.strip().split()]) for line in lines]

# Run scheduler and print results
scheduler = Scheduler(processes)
scheduler.run()
print("Average waiting time:", scheduler.get_avg_waiting_time())
print("Average turnaround time:", scheduler.get_avg_turnaround_time())
scheduler.print_gantt_chart()