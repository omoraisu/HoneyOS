import time

class PCB:
    def __init__(self, pID, arrival, burst_time, priority):
        self.pID = pID
        self.arrival = arrival
        self.burst_time = burst_time
        self.priority = priority
        self.completion_time = 0
        self.waiting_time = 0
        self.turnaround_time = 0
    
    def __str__(self):
        return f"Process {self.pID} | Arrival: {self.arrival} | Burst Time: {self.burst_time} | Priority: {self.priority}"
    # \nCompletion Time: {self.completion_time} | Waiting Time: {self.waiting_time} | Turnaround Time: {self.turnaround_time}

class Scheduler:
    def __init__(self, processes):
        self.processes = processes
        self.current_time = 0
        self.completed_processes = []
        self.queued_processes = []
        self.sequence = []
    
    def run(self):

        ready_process = None
        executing_process = None

        # Create a dictionary to store the original burst times
        original_burst_times = {}
        for process in self.processes:
            original_burst_times[process.pID] = process.burst_time

        while self.current_time <= self.processes[-1].arrival:

            # Check if there are any processes arriving at the current_time and load them in queue 
            for p in self.processes:
                if p.arrival == self.current_time:
                    self.queued_processes.append(p)

            # Sort the current queued processes by burst time 
            if self.queued_processes:
                self.queued_processes.sort(key=lambda x: (x.burst_time, x.pID)) 

            # Get the first process in the queue 
            ready_process = self.queued_processes.pop(0)

            # Change executing process to the one with lesser burst time 
            if executing_process == None or ready_process.burst_time <= executing_process.burst_time:
                executing_process = ready_process
                executing_process.burst_time -= 1
                self.current_time += 1
                self.queued_processes.append(executing_process)
                self.sequence.append((executing_process.pID, self.current_time, self.current_time))
            # If burst time is 0, remove process from queue and add to completed processes 
            elif executing_process and executing_process.burst_time == 0:
                executing_process.completion_time = self.current_time 
                executing_process.turnaround_time = executing_process.completion_time - executing_process.arrival
                executing_process.waiting_time = executing_process.turnaround_time - original_burst_times[executing_process.pID]
                self.sequence.append((executing_process.pID, self.current_time-executing_process.burst_time, self.current_time))
                self.completed_processes.append(executing_process)
                executing_process = self.queued_processes[0]

        while self.queued_processes:

            executing_process = self.queued_processes.pop(0)

            executing_process.completion_time = self.current_time + executing_process.burst_time
            executing_process.waiting_time = self.current_time
            executing_process.turnaround_time = executing_process.waiting_time + executing_process.burst_time
            self.current_time += executing_process.burst_time
            self.completed_processes.append(executing_process)
            self.sequence.append((executing_process.pID, self.current_time-executing_process.burst_time, self.current_time))


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

""""
with open("process3.txt") as f:
    lines = f.readlines()[1:] # Skip header line
    processes = [PCB(*[int(x) for x in line.strip().split()]) for line in lines]
"""

with open("process3.txt") as f:
    lines = f.readlines()[1:] # Skip header line
    processes = []
    for line in lines:
        try:
            pID, arrival, burst_time, priority = [int(x) for x in line.strip().split()]
            pcb = PCB(pID, arrival, burst_time, priority)
            processes.append(pcb)
        except ValueError:
            print(f"Error parsing line: {line}")

# Run scheduler and print results
scheduler = Scheduler(processes)
scheduler.run()
print("Average waiting time:", scheduler.get_avg_waiting_time())
print("Average turnaround time:", scheduler.get_avg_turnaround_time())
scheduler.print_gantt_chart()