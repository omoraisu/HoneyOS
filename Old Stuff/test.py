import random
import time
import os

class Resource:
    def __init__(self, id):
        self.id = id
        self.user = None
        self.time_left = 0
        
    def is_free(self):
        return self.user is None
    
    def allocate(self, user, time_to_use):
        self.user = user
        self.time_left = time_to_use
        # print(f"{user} is using Resource {self.id} for {time_to_use} seconds.")
        
    def update_time_left(self):
        if self.time_left > 0:
            self.time_left -= 1
            if self.time_left == 0:
                # print(f"{self.user} has finished using Resource {self.id}.")
                self.user = None
                
class User:
    def __init__(self, id, resources):
        self.id = id
        self.resources = resources
        self.requested_resource = None
        self.request_time = 0
        
    def request(self):
        if self.requested_resource is None:
            self.requested_resource = random.choice(self.resources)
            self.request_time = random.randint(1, 5)
            self.resources.remove(self.requested_resource)
            # print(f"{self} is requesting Resource {self.requested_resource.id} for {self.request_time} seconds.")
        
    def __str__(self):
        return f"User {self.id}"
    

def main():
    resources = [Resource(i+1) for i in range(random.randint(1, 3))]
    users = [User(i+1, resources[:]) for i in range(random.randint(1, 3))]
    resources_queue = []
    current_second = 0
    
    while resources or any(user.requested_resource is not None for user in users):
        # Check for users requesting a resource
        for user in users:
            user.request()
            if user.requested_resource is not None:
                resources_queue.append(user)
        
        # Check for free resources and allocate them to users in queue
        for resource in resources:
            if resource.is_free():
                if resources_queue:
                    user = min(resources_queue, key=lambda u: u.id)
                    resources_queue.remove(user)
                    resource.allocate(user, user.request_time)
        
        # Update time left for resources in use
        for resource in resources:
            resource.update_time_left()
        
        # Sleep for 1 second and update current second
        time.sleep(1)
        current_second += 1
        
        # Display status of resources
        print(f"\n-- Status at {current_second}s --")
        for resource in resources:
            if resource.is_free():
                print(f"Resource {resource.id}: Free")
            else:
                print(f"Resource {resource.id}: {resource.user} using for {resource.time_left} more second(s).")
                
        # Display users in queue
        if resources_queue:
            print("\nUsers in queue:")
            for user in resources_queue:
                print(f"{user} waiting for Resource {user.requested_resource.id}")
                
    print("\nAll user requests fulfilled and all resources are free.")
    
if __name__ == "__main__":
    main()
