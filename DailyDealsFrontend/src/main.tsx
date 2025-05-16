import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import CreateUser from './pages/user/create-user.tsx'
import { Provider } from './components/ui/provider.tsx'


createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Provider>
      <CreateUser />
    </Provider>
  </StrictMode>,
)
