import time
from tqdm import tqdm

# Set the time limit for using the resource
time_limit = 10

# Create a progress bar
for i in tqdm(range(time_limit)):
    # Do something while the resource is being used
    time.sleep(1)