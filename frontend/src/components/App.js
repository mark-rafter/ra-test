import './App.css';
import {
  useQuery,
  gql
} from "@apollo/client";
import { Event } from './Event';

const EVENTS_JANUARY2020 = gql`
  query GetEvents {
    events(dateFrom:"2020-01-01" dateTo:"2020-01-02") {
      id
      title
      date
      startTime
      endTime
    }
  }
`;

function Events() {
  const { loading, error, data } = useQuery(EVENTS_JANUARY2020);
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
      <Events />
    </div>
  );
}

export default App;
