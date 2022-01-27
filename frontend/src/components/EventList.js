import { useQuery, gql } from "@apollo/client";

const EVENTS = gql`
  query GetEvents($from: DateTime!, $to: DateTime!) {
    events(dateFrom: $from, dateTo: $to) {
      id
      title
      date
      venue { 
        name
      }
      artists {
        name
      }
      promoters { 
        name
      }
      startTime
      endTime
    }
  }
`;

function Event({ id, title, date, venue, artists, promoters, startTime, endTime }) {
  return <li key={id}>
    <p>{new Date(date).toLocaleDateString()}</p>
    <p>{venue.name}</p>
    <p>{title}</p>
    <p>{new Date(startTime).toLocaleTimeString()} &mdash; {new Date(endTime).toLocaleTimeString()}</p>
    <p>Artists:
      <ul>
        {artists.map((a) => (
          <li>{a.name}</li>
        ))}
      </ul>
    </p>
    <p>Promoters:
      <ul>
        {promoters.map((p) => (
          <li>{p.name}</li>
        ))}
      </ul>
    </p>
  </li>;
}

export default function EventList({ from, to }) {
  const { loading, error, data } = useQuery(EVENTS, {
    variables: { from, to },
  });

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error :(</p>;

  return <ul>
    {data.events.map((e) => (
      Event(e)
    ))}</ul>;
}
