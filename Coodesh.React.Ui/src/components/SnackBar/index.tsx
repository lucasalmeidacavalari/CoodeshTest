import React, { useState, useEffect } from 'react';
import PropTypes from 'prop-types';
import './snackbar.scss';

const Snackbar = ({ message, duration }: any) => {
  const [visible, setVisible] = useState(true);
  const [progress, setProgress] = useState(0);

  useEffect(() => {
    let progressInterval: any;
    let fadeTimeout: any;

    if (visible) {
      progressInterval = setInterval(() => {
        setProgress(prevProgress => prevProgress + 1);
      }, duration / 100);

      fadeTimeout = setTimeout(() => {
        setVisible(false);
        clearInterval(progressInterval);
      }, duration);
    }

    return () => {
      clearInterval(progressInterval);
      clearTimeout(fadeTimeout);
    };
  }, [visible, duration]);

  const handleClose = () => {
    setVisible(false);
  };

  return (
    <>
      {visible && (
        <div className="snackbar-container">
          <div className="snackbar-content">
            <div className="snackbar-message" dangerouslySetInnerHTML={{ __html: message }}></div>
            <div className="snackbar-progress">
              <div
                className="snackbar-progress-bar"
                style={{ width: `${progress}%` }}
              />
            </div>
          </div>
          <button className="snackbar-close" onClick={handleClose}>
            Fechar
          </button>
        </div>
      )}
    </>
  );
};

Snackbar.propTypes = {
  message: PropTypes.string.isRequired,
  duration: PropTypes.number.isRequired,
};

export default Snackbar;
