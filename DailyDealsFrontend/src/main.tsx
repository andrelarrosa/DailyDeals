import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import CreateUser from './pages/user/create-user.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <CreateUser />
  </StrictMode>,
)
