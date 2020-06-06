# Log Aggregation Demo

This demonstration uses the structured Logging Feature of NLog
to provide JSON records to Logstash via TCP.
Logstash processes the JSON file and stores the results in Elastic Search.
Elastic Search data is visualized by Kibana.

1. Setup environment with docker-compose:
   ```sh
   docker-compose up -d
   ```
2. ISsue requests using curl, e.g.
   ```sh
   docker exec log_aggregation_demo_app curl -sS -X PUT -H 'Content-Type: application/json;charset=utf-8' -d '{"state":"This is the new state"}' kong:8000
   docker exec log_aggregation_demo_app curl -sS -H "Accept: application/json;charset=utf-8" kong:8000
   ```
3. On the docker host open a web browser and navigate to <http://localhost:5601/>
4. Cleanup
   ```sh
   docker-compose down
   ```
