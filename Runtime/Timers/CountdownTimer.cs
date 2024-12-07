using System;
using UnityEngine;

namespace ImprovedTimers {
    /// <summary>
    /// Timer that counts down from a specific value to zero.
    /// </summary>
    public class CountdownTimer : Timer {
        public CountdownTimer(float value) : base(value) { }
        
        public Action OnEnd;

        public override void Tick() {
            if (IsRunning && CurrentTime > 0) {
                CurrentTime -= Time.deltaTime;
            }

            if (IsRunning && CurrentTime <= 0) {
                OnEnd.Invoke();
                Stop();
            }
        }

        public override bool IsFinished => CurrentTime <= 0;
    }
}
