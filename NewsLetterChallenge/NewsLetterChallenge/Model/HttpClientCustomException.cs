using System;
using System.Runtime.Serialization;

namespace NewsLetterChallenge.Model
{
	[Serializable]
	internal class HttpClientCustomException : Exception
	{
		private string v;
		private int statusCode;
		private string responseData;
		private object headers;
		private Exception exception;

		public HttpClientCustomException()
		{
		}

		public HttpClientCustomException(string message) : base(message)
		{
		}

		public HttpClientCustomException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public HttpClientCustomException(string v, int statusCode, string responseData, object headers, Exception exception)
		{
			this.v = v;
			this.statusCode = statusCode;
			this.responseData = responseData;
			this.headers = headers;
			this.exception = exception;
		}

		protected HttpClientCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}