export function Event(id, title, date, startTime, endTime) {
    return <li key={id}>
        <p>{new Date(date).toLocaleDateString()}</p>
        <p>{title}</p>
        <p>{new Date(startTime).toLocaleTimeString()} &mdash; {new Date(endTime).toLocaleTimeString()}</p>
    </li>;
}
