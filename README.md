# Coding Test

This is the Resident Advisor coding test. Please submit your answer privately,
and do not post to a public repo.

The aim of this is to demonstrate your coding ability and understanding, not to
produce a production-grade application. If you don't have
time to complete all the tasks, be prepared to at least talk
us through how you would have approached them.

## Background

There are two subfolders in this repository. `frontend/` and `backend/`. The
backend folder contains a basic implementation of a GraphQL server, written in
C# using the dotnet core framework. The frontend folder contains an empty react
project, created using
[create-react-app](https://github.com/facebook/create-react-app)

The aim of this test is to build a react app that can display event listings,
by consuming the GraphQL api.

The current implementation of the api has some hardcoded data in it, to get you
started. A sample of real data is provided in `backend/data/`.

### GraphQL Playground

To help you out, there is a GraphQL playground UI bundled into the api. This
lets you interactively run queries to test them out.

To see it run

    cd backend
    dotnet restore
    dotnet run

Then go to https://localhost:5001/graphql to use the playground. The following
query should return some data.

    {
      events(dateFrom:"2020-01-01" dateTo:"2020-01-02") {
        id
        title
        date
        startTime
        endTime
      }
    }


## Resources

- [Download .NET](https://dotnet.microsoft.com/download)  
- [GraphQL](https://graphql.org)
- [Create React App](https://github.com/facebook/create-react-app)
- [Getting started with GraphQL](https://www.apollographql.com/docs/react/get-started/)
- [Hotchocolate](https://chillicream.com/docs/hotchocolate)

## Tasks

You should approach these tasks as if you were working on them during a sprint.
Feel free to use whatever resources or third party libraries that you want.

### Task 1

Build a react app that consumes the initial api to display a list of events.
Apply some simple styling to this page.

### Task 2

The initial api uses hardcoded event data. Modify it to instead read the
event data provided in `backend/data/events.json`.

### Task 3

The initial api takes the arguments `dateFrom` and `dateTo` on the `events`
endpoint. However, it doesn't do anything with these arguments. Modify the api
so that these arguments are used to return a filtered list of events. Add some
controls onto your frontend so that you can filter the event listing by date.

### Task 4

The initial api does not support returning names of promoters, artists or
venues for each event. Modify the api so that it supports returning this nested
information for each event. Update the frontend to fetch this data from the api
and display it in the event listing.

## Further Work

If you have time, or feel like you want to, you can add some more features or
capabilities to the application. You could add anything you wanted from a
backend performance optoimisation through to a novelty frontend feature. This
is not required and don't feel like you have to if you have spent a lot of time
on this already.
