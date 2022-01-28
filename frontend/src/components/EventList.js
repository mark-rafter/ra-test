import { useQuery, gql } from "@apollo/client";
import './EventList.css';

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
        id
        name
      }
      promoters { 
        id
        name
      }
      startTime
      endTime
    }
  }
`;

function Event({ id, title, date, venue, artists, promoters, startTime, endTime }) {
  function formatTime(time) {
    return new Date(time).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
  }

  return <article>
    <p>{new Date(date).toLocaleDateString()}</p>
    <p>{formatTime(startTime)} &mdash; {formatTime(endTime)}</p>
    <p>{title} @ {venue.name}</p>
    {artists?.length > 0 &&
      <div>Artists:
        <ul>
          {artists.map((a) => (
            <li key={a.id}>
              {a.name}
            </li>
          ))}
        </ul>
      </div>}
    {promoters?.length > 0 &&
      <div>Promoters:
        <ul>
          {promoters.map((p) => (
            <li key={p.id}>
              {p.name}
            </li>
          ))}
        </ul>
      </div>}
  </article>;
}

export default function EventList({ from, to }) {
  const { loading, error, data } = useQuery(EVENTS, {
    variables: { from, to },
  });

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error :(</p>;

  return <section className="flex-container">
    {data.events.map((e) =>
      <Event key={e.id} {...e} />
    )}</section>;
}
