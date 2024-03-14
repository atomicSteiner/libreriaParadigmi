namespace libreriaParadigmi.Web.Extensions
{
    public static class MiddlewareExtension
    {
        public static WebApplication? AddWebMiddleware(this WebApplication? app)
        {
            if (app == null)
            {
                return null;
            }
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllers();
            return app;
        }
    }
}
