import { render, screen } from '@testing-library/react';
import App from './App';

test('renders events header', () => {
  render(<App />);
  const linkElement = screen.getByText(/Events/i);
  expect(linkElement).toBeInTheDocument();
});
