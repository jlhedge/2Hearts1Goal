# Messaging Module

Recommended progression:

- start with a SQL outbox table inside the monolith
- add a background dispatcher
- introduce RabbitMQ only when worker volume or integration needs justify it

That keeps delivery reliable without forcing distributed infrastructure too early.
