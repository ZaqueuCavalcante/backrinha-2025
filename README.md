# Rinha de Backend 2025

[![Tests](https://github.com/ZaqueuCavalcante/backrinha-2025/actions/workflows/tests.yml/badge.svg)](https://github.com/ZaqueuCavalcante/backrinha-2025/actions/workflows/tests.yml)

Essa é minha solução da Rinha de Backend 2025.

https://github.com/zanfranceschi/rinha-de-backend-2025

https://github.com/zanfranceschi/rinha-de-backend-2025/blob/main/INSTRUCOES.md

https://github.com/zanfranceschi/rinha-de-backend-2025/issues/11

...



$Env:K6_BROWSER_ENABLED='true'
$Env:K6_WEB_DASHBOARD='true'
$Env:K6_WEB_DASHBOARD_PORT='5665'
$Env:K6_WEB_DASHBOARD_PERIOD='2s'
$Env:K6_WEB_DASHBOARD_OPEN='true'
$Env:K6_WEB_DASHBOARD_EXPORT='report.html'

k6 run --out 'web-dashboard' rinha.js


