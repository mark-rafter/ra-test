import './App.css';
import { useState } from "react";
import DayPicker, { DateUtils } from "react-day-picker";
import "react-day-picker/lib/style.css";
import EventList from './EventList';

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
      <div>
        <p>
          {!from && !to && "Please select the first day."}
          {from && !to && "Please select the last day."}
          {from && to && `Selected from ${from.toLocaleDateString()} to ${to.toLocaleDateString()}`}
          {" "}
          {from && to && (
            <button className="link" onClick={handleResetClick}>
              Reset
            </button>
          )}
        </p>
        <DayPicker
          className="Selectable"
          month={new Date(2019, 9)}
          numberOfMonths={1}
          selectedDays={[from, { from, to }]}
          modifiers={modifiers}
          onDayClick={handleDayClick}
        />
      </div>
      {from && to && <EventList from={from} to={to} />}
    </div>
  );
}

export default App;
