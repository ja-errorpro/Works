# For Reports

## GitHub上傳方式(已裝好Git):
1. 在一空白資料夾點擊右鍵開啟git bash here
2. 指令(網址為點擊綠色區塊按鈕進行複製)
	$ git clone 網址(github.com/xxx/yyy.git)
3. 將要上傳的檔案丟進專案資料夾(yyy)
4. 指令,檢查是否有檔案被修改過(紅色文字即修改過的檔案)
	$ git status
5. 指令,將已新增的檔案加入
	$ git add .
6. 重複第4步,確認檔案是否成功加入
7. 指令
	$ git commit -m "隨便打"
8. 指令,上傳完成
	$ git push