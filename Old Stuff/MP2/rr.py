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
    def __init__(self, processes, time_slice):
        self.processes = processes
        self.current_time = 0
        self.time_slice = time_slice
        self.completed_processes = []
        self.sequence = []
    
    def run(self):
        # Create a dictionary to store the original burst times
        original_burst_times = {}
        for process in self.processes:
            original_burst_times[process.pID] = process.burst_time

        while self.processes:
            executing_process = self.processes.pop(0) 
            if executing_process.burst_time > self.time_slice:
                # If the process has more time left than the time quantum, execute it for the quantum and add it back to the end of the list
                executing_process.burst_time -= self.time_slice
                self.current_time += self.time_slice
                self.sequence.append((executing_process.pID, self.time_slice))
                self.processes.append(executing_process)
            else:
                # If the process has less time left than the time quantum, execute it for the remaining time and mark it as completed
                self.current_time += executing_process.burst_time
                executing_process.turnaround_time = self.current_time

                # Get the original burst time from the dictionary
                og_burst_time = original_burst_times[executing_process.pID]

                executing_process.waiting_time = executing_process.turnaround_time - og_burst_time

                self.sequence.append((executing_process.pID, executing_process.burst_time))
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
        for s in self.sequence:
            print("P" + str(s[0]), end="")
            for i in range(s[1]):
                print("-", end="")
            print(" ", end="")
        print()


with open("process2.txt") as f:
    lines = f.readlines()[1:] # Skip header line
    processes = [PCB(*[int(x) for x in line.strip().split()]) for line in lines]

# Run scheduler and print results
scheduler = Scheduler(processes, 4)
scheduler.run()
print("Average waiting time:", scheduler.get_avg_waiting_time())
print("Average turnaround time:", scheduler.get_avg_turnaround_time())
scheduler.print_gantt_chart()
