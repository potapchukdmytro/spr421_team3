
import { Routes,Route } from 'react-router'
import './App.css'
import DefLayouts from './components/layouts/DefLayouts'
import HousePage from './pages/HousePage/HousePage'

function App() {


  return (
    <Routes>
      <Route path ="/" element={<DefLayouts/>}>
      <Route index element={<HousePage/>}></Route>
      </Route>

    </Routes>
  )
}

export default App
