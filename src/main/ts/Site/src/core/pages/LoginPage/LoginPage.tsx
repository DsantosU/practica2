import React from 'react';
import { NavLink } from 'react-router-dom';
import './LoginPage.scss';

const LoginPage = () => (
  <div className="login-page">
    <div className="login-banner">
      <p />
    </div>
    <div className="login-form">
      <div className="container">
        <div className="row">
          <div className="mb-5 d-flex justify-content-center">
            <img className="logo" src="../../../assets/images/RI-peq-300x196.png" alt="logo" />
          </div>
        </div>
        <div className="row">
          <form>
            <div className="mb-3">
              <label htmlFor="email" className="form-label">Correo Electrónico</label>
              <input type="text" className="form-control" id="email" aria-describedby="emailHelp" />

            </div>
            <div className="mb-3">
              <label htmlFor="password" className="form-label">Contraseña</label>
              <input type="password" className="form-control" id="password" />
            </div>

            <div className="mb-1">
              <div className="row">
                <div className="col-6 d-flex justify-content-start">
                  <p className="text-link">Recordarme</p>
                </div>
                <div className="col-6 d-flex justify-content-end">
                  <p className="text-link">Olvide mi contraseña</p>
                </div>
              </div>
            </div>

            <div className="mb-2">
              <div className="d-grid gap-2">

                <NavLink to="/home" className="btn primary-button">

                  Iniciar sesión

                </NavLink>

              </div>
            </div>

            <div className="row">
              <div className="col d-flex justify-content-end gap-3">
                <p>
                  No poseo una cuenta
                </p>
                <span className="text-link">Registrarme</span>
              </div>

            </div>

            <hr />
          </form>
        </div>
      </div>
    </div>
  </div>
);

export default LoginPage;
