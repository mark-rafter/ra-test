import './App.css';
import {
  useQuery,
  gql
} from "@apollo/client";
import { Event } from './Event';
import { useState } from "react";
import DayPicker, { DateUtils } from "react-day-picker";
import "react-day-picker/lib/style.css";

const EVENTS_SEPT2019 = gql`
  query GetEvents {
    events(dateFrom: "2019-10-01", dateTo: "2019-10-01") {
      id
      title
      date
      startTime
      endTime
    }
  }
`;

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
  // const dateFrom = "2019-10-01";
  // const dateTo = "2019-10-01";
  // const { loading, error, data } = useQuery(EVENTS, {
  //   variables: { dateFrom, dateTo },
  // });
  const { loading, error, data } = useQuery(EVENTS_SEPT2019);
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error :(</p>;

  return <ul>
    {data.events.map(({ id, title, date, startTime, endTime }) => (
      Event(id, title, date, startTime, endTime)
    ))}</ul>;
}

function App() {
  const [from, setFrom] = useState(undefined);
  const [to, setTo] = useState(undefined);

  const modifiers = { start: from, end: to };

  function handleDayClick(day) {
    const range = DateUtils.addDayToRange(day, { from, to });
    setFrom(range.from);
    setTo(range.to);
  }

  function handleResetClick() {
    setFrom(undefined);
    setTo(undefined);
  }

  return (
    <div className="App">
      <h1>Events</h1>
      <div className="RangeExample">
        <p>
          {!from && !to && "Please select the first day."}
          {from && !to && "Please select the last day."}
          {from &&
            to &&
            `Selected from ${from.toLocaleDateString()} to
                ${to.toLocaleDateString()}`}{" "}
          {from && to && (
            <button className="link" onClick={handleResetClick}>
              Reset
            </button>
          )}
        </p>
        <DayPicker
          className="Selectable"
          numberOfMonths={1}
          selectedDays={[from, { from, to }]}
          modifiers={modifiers}
          onDayClick={handleDayClick}
        />
      </div>
      {from && to && <EventList />}
    </div>
  );
}

export default App;
