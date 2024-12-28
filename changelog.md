# 变更日志

本项目的所有重要变更都将记录在此文件中。

## [] - 2024-12-28

### 新增

### 修改

- `ImageConvertTaskHandler`、`ImageScaleTaskHandler` 与 `ImageWatermarkTaskHandler` 修改为从 `TaskHandlerBase` 类继承

### 移除

- 删除 `TaskCoverHandler` 类，使用 `Bee.Base` 程序集中的默认实现
