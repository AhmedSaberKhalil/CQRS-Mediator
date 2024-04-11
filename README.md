CQRS stands for Command and Query Responsibility Segregation and uses to separate read(queries) and write(commands).
In that, queries perform read operation, and command perform writes operation like create, update, delete, and return data.

When to use CQRS:
We can use Command Query Responsibility Segregation when the application is huge and access the same data in parallel.
CQRS helps reduce merge conflicts while performing multiple operations with data.
In DDD terminology, if the domain data model is complex and needs to perform many operations on priority like validations and executing some business logic so in that case,
we need the consistency that we will by using CQRS.

MediatR:
MediatR pattern helps to reduce direct dependency between multiple objects and make them collaborative through MediatR.
