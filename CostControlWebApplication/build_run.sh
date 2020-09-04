

docker build -t costcontrol .

docker run -t -p 5100:80 --name=costcontrol  costcontrol  --privileged=true