class PCB:
    def __init__(self, pID, arrival, burst_time, priority):
        self.pID = pID
        self.arrival = arrival
        self.burst_time = burst_time
        self.priority = priority
        self.waiting_time = 0
        self.turnaround_time = 0

class Scheduler:
    def __init__(self, processes):
        self.processes = processes
        self.current_time = 0
        self.completed_processes = []
        self.current_process = None
    
    def run(self):
        while self.processes or self.current_process:
            # Check if there is a process to execute
            if self.current_process is None:
                self.processes.sort(key=lambda p: (p.arrival, p.burst_time, p.pID))
                if self.processes and self.processes[0].arrival <= self.current_time:
                    self.current_process = self.processes.pop(0)
                    self.current_process.waiting_time = self.current_time - self.current_process.arrival
            
            # Execute the current process for one unit of time
            if self.current_process is not None:
                self.current_process.burst_time -= 1
                if self.current_process.burst_time == 0:
                    self.current_process.turnaround_time = self.current_time + 1 - self.current_process.arrival
                    self.completed_processes.append(self.current_process)
                    self.current_process = None
            
            self.current_time += 1
            
            # Check if there is a shorter process to execute
            if self.current_process is not None:
                for p in self.processes:
                    if p.arrival > self.current_time:
                        break
                    if p.burst_time < self.current_process.burst_time:
                        self.processes.append(self.current_process)
                        self.current_process = self.processes.pop(self.processes.index(p))
                        self.current_process.waiting_time = self.current_time - self.current_process.arrival
                        break
    
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
            for i in range(p.turnaround_time):
                print("-", end="")
            print(" ", end="")
        print()

with open("process1.txt") as f:
    lines = f.readlines()[1:] # Skip header line
    processes = [PCB(*[int(x) for x in line.strip().split()]) for line in lines]

# Run scheduler and print results
scheduler = Scheduler(processes)
scheduler.run()
print("Average waiting time:", scheduler.get_avg_waiting_time())
print("Average turnaround time:", scheduler.get_avg_turnaround_time())
scheduler.print_gantt_chart()