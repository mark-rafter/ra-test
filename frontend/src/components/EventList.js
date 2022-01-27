import { useQuery, gql } from "@apollo/client";
import Event from './Event';

export const EVENTS = gql`
  query GetEvents($from: DateTime!, $to: DateTime!) {
    events(dateFrom: $from, dateTo: $to) {
      id
      title
      date
      startTime
      endTime
    }
  }
`;

export default function EventList({ from, to }) {
    const { loading, error, data } = useQuery(EVENTS, {
        variables: { from, to },
    });

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error :(</p>;

    return <ul>
        {data.events.map(({ id, title, date, startTime, endTime }) => (
            Event(id, title, date, startTime, endTime)
        ))}</ul>;
}
