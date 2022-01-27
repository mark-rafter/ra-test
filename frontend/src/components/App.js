import './App.css';
import {
  useQuery,
  gql
} from "@apollo/client";
import { Event } from './Event';
import { DateRangePicker } from './DateRangePicker';

const EVENTS = gql`
  query GetEvents($dateFrom: DateTime!, $dateTo: DateTime!) {
    events(dateFrom: $dateFrom, dateTo: $dateTo) {
      id
      title
      date
      startTime
      endTime
    }
  }
`;

function EventList() {
  const { loading, error, data } = useQuery(EVENTS, {
    variables: { dateFrom, dateTo },
  });
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error :(</p>;

  return <ul>
    {data.events.map(({ id, title, date, startTime, endTime }) => (
      Event(id, title, date, startTime, endTime)
    ))}</ul>;
}

function App() {
  return (
    <div className="App">
      <h1>Events</h1>
      <DateRangePicker />
      <EventList />
    </div>
  );
}

export default App;
