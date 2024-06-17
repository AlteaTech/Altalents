Remove-Item -Path ./ui/Altalents.MVC/wwwroot/js/app-client.js;
Remove-Item -Path ./ui/Altalents.MVC/wwwroot/css/app-client.css;
Remove-Item -Path ./ui/Altalents.MVC/wwwroot/assets/i18n/en.json;
Remove-Item -Path ./ui/Altalents.MVC/wwwroot/assets/i18n/fr.json;

cd ./ui/Altalents.MVC/Angular/Altalents-client
npm i;
ng build --configuration production ;

$content = Get-Content -Path "./dist/Altalents-client/main.*.js";
$newContent = $content -replace '"use strict";', '';
$newContent | Set-Content -Path "./dist/Altalents-client/main.*.js"


$content = Get-Content -Path "./dist/Altalents-client/polyfills.*.js";
$newContent = $content -replace '"use strict";', '';
$newContent | Set-Content -Path "./dist/Altalents-client/polyfills.*.js"

$content = Get-Content -Path "./dist/Altalents-client/runtime.*.js";
$newContent = $content -replace '"use strict";', '';
$newContent | Set-Content -Path "./dist/Altalents-client/runtime.*.js"


Read-Host -Prompt 'Ok'