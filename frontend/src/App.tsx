import { useEffect, useState } from 'react';
import './App.css';

type Drink = {
  id: number;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
};

function App() {
  const [drinks, setDrinks] = useState<Drink[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch('http://localhost:5271/drinks')
      .then(res => res.json())
      .then(data => {
        setDrinks(data);
        setLoading(false);
      })
      .catch(() => setLoading(false));
  }, []);

  if (loading) {
    return <div className="container"><h1>Загрузка...</h1></div>;
  }

  return (
    <div className="container">
      <h1>Меню бара</h1>
      <div className="grid">
        {drinks.map(drink => (
          <div className="card" key={drink.id}>
            <img src={drink.imageUrl} alt={drink.name} />
            <h2>{drink.name}</h2>
            <p>{drink.description}</p>
            <span>{drink.price} грн</span>
          </div>
        ))}
      </div>
    </div>
  );
}

export default App;
