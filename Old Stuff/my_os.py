"""
Daenielle Rai Peladas
CMSC 125: Operating Systems 
Laboratory Exercise 1: On Time-Sharing Systems
"""

import random
import time
from tqdm import tqdm

RESOURCE_AVAILABLE = "IDLE"          # resource is open for use
RESOURCE_IN_USE = "BUSY"             # resource is currently being used     

USER_AVAILABLE = "AVAILABLE"         # user is not using any resources 
USER_USING_RESOURCE = "ACTIVE"       # user is using resources 
USER_WAITING = "WAITING"             # user is waiting for a resource to free up 

class Resource:
    def __init__(self, resource_number):
        self.resource_number = resource_number
        self.status = RESOURCE_AVAILABLE
        self.current_user = User(None)
        self.users = {}
        self.time_left = 0

    def allocate(self, user, time_use):
        self.users[user] = time_use 
    
    def request(self, req_user):
        for user, req_time in self.users.items():
            if user.id == req_user:
                self.status = RESOURCE_IN_USE
                self.current_user, self.time_left = user, req_time
                self.users.pop(self.current_user) 
                break
    
    def time_update(self):
        if self.time_left > 0:
            self.time_left -= 1 
    
    def is_times_up(self):
        if self.time_left == 0:
            return True
        return False 
    
    def is_queue_empty(self):
        if self.users:
            return False
        return True

    def __str__(self):
        return f"Resource {self.resource_number}"

    def print_current_users(self):
        user_str = ""
        user_str += f"Now: {self.current_user} ({self.time_left}) seconds left.\n"
        if self.users:
            user_str = "Current users: "
            for user, time_use in self.users.items():
                user_str += f"[User {user.id} ({time_use} seconds left)] "
        print(f"Resource {self.resource_number}\n{user_str}\n")

class User:
    def __init__(self, id):
        self.id = id
        self.status = USER_AVAILABLE
        self.requested_resource = None 
        self.request_time = 0 
        self.resources = {} 
    
    def add_resource(self, resource, req_time):
        self.resources[resource] = req_time
    
    def request_resource(self):
        if self.resources:
            self.requested_resource, self.request_time = next(iter(self.resources.items()))
            self.resources.pop(self.requested_resource)
    
    def get_availability(self):
        return self.status
    
    def __str__(self):
        user_str = ""
        if self.resources:
            user_str = f"User {self.id}\n"
            for resource, time_use in self.resources.items():
                user_str += f"{str(resource)} ({time_use} seconds)\n"
        else:
            user_str = f"User {self.id} has no resources."
        return user_str

def print_states(resources, time_elapsed):
    print("--------------------\n")
    print(f"Time Elapsed: {time_elapsed}\n")
    print("--------------------\n")
    for item in resources:
        item.print_current_users() 
    print("--------------------\n")


def main():
    resources = [Resource(i+1) for i in range(3)]
    users = [User(i+1) for i in range(3)]

    time_elapsed = 0
    clear_counter = len(resources)

    # allocates random resources to users 
    for user in users:
        number_of_resources = random.randint(1, len(resources))
        resource_indices = random.sample(range(len(resources)), number_of_resources)
        
        for i in resource_indices:
            resource = resources[i]
            req_time = random.randint(1,10)
            user.add_resource(resource, req_time)
            resources[i].allocate(user, req_time)

    while clear_counter != 0:
        print_states(resources, time_elapsed)
        # goes through each user and asks resource request 
        for user in users: 
            user.request_resource() # updates current resource and time_left in user according to list  sequence
            for resource in resources: # when resource is  available
                # print(f'Resource: {resource.resource_number}\nStatus: {resource.status}\nCurrent User: {resource.current_user}\nRequest Time: {resource.time_left}\nQueued Users: {resource.users}\n')
                if resource == user.requested_resource and resource.status == RESOURCE_AVAILABLE and user.status == USER_AVAILABLE:
                    user.status = USER_USING_RESOURCE 
                    resource.request(user.id) # updates status, current user, and req_time left in resource
                    break
                elif resource == user.requested_resource and resource.status == RESOURCE_IN_USE and user.status == USER_AVAILABLE:
                    user.status = USER_AVAILABLE
                    user.add_resource(resource, resource.time_left)
                    resource.allocate(user, resource.time_left)
            
            resource.time_update() 
            # print(f'User: {user.id}\nStatus: {user.status}\nRequested Resource: {user.requested_resource}\nRequest Time: {user.request_time}\nQueued Resources: {user.resources}\n')
            # print(f'AFTER\nUser: {user.id}\nStatus: {user.status}\nRequested Resource: {user.requested_resource}\nRequest Time: {user.request_time}\nQueued Resources: {user.resources}\n')

             

        if resource.is_times_up() == True:
            resource.status = RESOURCE_AVAILABLE
            resource.current_user = None
            user.status = USER_AVAILABLE
                
        if resource.is_queue_empty() == True:
            clear_counter -= 1              
            print(f'\n{resource} is cleared.\n')
        
        # print(f'Resource: {resource.resource_number}\nStatus: {resource.status}\nCurrent User: {resource.current_user}\nRequest Time: {resource.time_left}\nQueued Users: {resource.users}\n')
                    
        time_elapsed += 1   
        time.sleep(5)

        
    

    

if __name__ == '__main__':
    main()


    
