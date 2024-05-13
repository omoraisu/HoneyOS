"""
Daenielle Rai Peladas
CMSC 125: Operating Systems 
Laboratory Exercise 1: On req_time-Sharing Systems
"""

import random
import time
from tqdm import tqdm

RESOURCE_AVAILABLE = "IDLE"          # resource is open for use
RESOURCE_IN_USE = "BUSY"             # resource is currently being used     

USER_AVAILABLE = "AVAILABLE"         # user is not using any resources 
USER_USING_RESOURCE = "ACTIVE"       # user is using resources 
USER_WAITING = "WAITING"             # user is waiting for a resource to free up 
USER_REQUESTING_RESOURCE = "REQUESTING"

class User:
    def __init__(self, id):
        self.id = id
        self.resources = []
        self.status = USER_AVAILABLE
        self.requested_resource = None
        self.time_left = 0
        
    def add_resource(self, resource, req_time):
        self.resources.append((resource, req_time))
        
    def request_resource(self):
        if self.status == USER_AVAILABLE:
            self.status = USER_REQUESTING_RESOURCE
            for resource, req_time in self.resources:
                if resource.status == RESOURCE_AVAILABLE:
                    self.requested_resource = resource
                    self.time_left = req_time
                    resource.add_to_queue(self)
                    break
                    
    def release_resource(self, resource):
        for i, (r, _) in enumerate(self.resources):
            if r == resource:
                self.resources.pop(i)
                break
        self.status = USER_AVAILABLE
        self.requested_resource = None
        self.time_left = 0
        
        
class Resource:
    def __init__(self, id):
        self.id = id
        self.status = RESOURCE_AVAILABLE
        self.current_user = None
        self.queue = []
        self.time_left = 0
        
    def add_to_queue(self, user):
        self.queue.append(user)
        
    def request(self, user_id):
        self.status = RESOURCE_IN_USE
        self.current_user = user_id
        
    def deallocate(self):
        self.status = RESOURCE_AVAILABLE
        self.current_user = None
        
    def allocate(self, user, req_time):
        self.status = RESOURCE_IN_USE
        self.current_user = user.id
        self.time_left = req_time
        
    def time_update(self):
        self.time_left -= 1
        
    def is_times_up(self):
        return self.time_left == 0
        
    def is_queue_empty(self):
        return len(self.queue) == 0
    
    def print_current_users(self):
        print(f"Resource {self.id}")
        if self.current_user:
            print(f"Current user: User {self.current_user} ({self.time_left} seconds left)")
        else:
            print("Current user: None")
        print("Queue: ", end="")
        if self.queue:
            print([f"User {user.id}" for user in self.queue])
        else:
            print("None")

def print_states(resources, time_elapsed):
    print("--------------------\n")
    print(f"req_time Elapsed: {time_elapsed}\n")
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
            resource.allocate(user, req_time)

    while clear_counter != 0:
        print_states(resources, time_elapsed)
        for resource in resources:
            # if a resource has no current user
            if resource.current_user is None:
                # and there are users waiting in the queue
                if len(resource.queue) > 0:
                    user = resource.queue[0]
                    # and the user is available to use the resource
                    if user.status == USER_AVAILABLE:
                        user.status = USER_USING_RESOURCE
                        # allocate the resource to the user
                        resource.request(user.id)
                        # set the user's time_left and resource's time_left
                        resource.time_left = user.resources[resource]
                        user.time_left = resource.time_left
                        # remove the user from the queue
                        resource.queue.pop(0)
        
        # update the status of the users and resources
        for user in users: 
            user.request_resource()
            resource = user.requested_resource
            # if the user has a requested resource
            if resource is not None:
                # and the resource is available
                if resource.status == RESOURCE_AVAILABLE and user.status == USER_AVAILABLE:
                    user.status = USER_USING_RESOURCE
                    resource.request(user.id)
                    resource.time_left = user.time_left
                    resource.time_update()
            # if the user is currently using a resource
            elif user.status == USER_USING_RESOURCE:
                resource = user.allocated_resources[user.current_resource_index]
                # if the req_time is up for the resource
                if resource.is_times_up():
                    resource.status = RESOURCE_AVAILABLE
                    resource.current_user = None
                    user.status = USER_AVAILABLE
                    # move to the next allocated resource
                    user.current_resource_index += 1
                    # if there are no more resources to use, remove user from allocated resources of all resources
                    if user.current_resource_index == len(user.allocated_resources):
                        for res in user.allocated_resources:
                            res.current_user = None
                            res.status = RESOURCE_AVAILABLE
                        user.allocated_resources = []
        
        # check if any resources are cleared up
        for resource in resources:
            if resource.status == RESOURCE_AVAILABLE and len(resource.queue) == 0 and resource.current_user is None:
                clear_counter -= 1

        time_elapsed += 1   
        time.sleep(1)

if __name__ == '__main__':
    main()

