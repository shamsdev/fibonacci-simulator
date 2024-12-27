using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class FibonacciController : MonoBehaviour
{
    [SerializeField] private BoxController boxPrefab;
    [SerializeField] private Transform boxContainer;

    private float currentMaxSize = 1;
    private void Start()
    {
        GenerateFibonacci(10);
        StartCoroutine(nameof(AdjustContainerScale));
    }

    private async void GenerateFibonacci(int steps)
    {
        var generatePos = 3; // 0: right, 1: up, 2: left, 3: down
        BoxController lastBox = null;

        var sequence = FibonacciGenerator.GenerateFibonacciSequence(steps);

        foreach (var num in sequence)
        {
            if (num == 0)
                continue;

            var box = Instantiate(boxPrefab, boxContainer);
            var boxTransform = box.transform;

            box.Set(num);
            currentMaxSize = num;

            if (lastBox == null)
            {
                boxTransform.localPosition = Vector3.zero;
            }
            else
            {
                var lastPos = lastBox.transform.localPosition;

                boxTransform.localPosition = generatePos switch
                {
                    0 => // Right
                        lastPos + new Vector3(lastBox.GetSize() / 2 + box.GetSize() / 2,
                            -lastBox.GetSize() / 2 + box.GetSize() / 2, 0f),
                    1 => // Up
                        lastPos + new Vector3(lastBox.GetSize() / 2 - box.GetSize() / 2,
                            lastBox.GetSize() / 2 + box.GetSize() / 2, 0f),
                    2 => // Left
                        lastPos + new Vector3(-lastBox.GetSize() / 2 - box.GetSize() / 2,
                            lastBox.GetSize() / 2 - box.GetSize() / 2, 0f),
                    3 => // Down
                        lastPos + new Vector3(-lastBox.GetSize() / 2 + box.GetSize() / 2,
                            -lastBox.GetSize() / 2 - box.GetSize() / 2, 0f),
                    _ => boxTransform.localPosition
                };

            }


            // Prepare for the next loop
            lastBox = box;
            generatePos = (generatePos + 1) % 4;

            // A small delay so you see the placement happen gradually
            await Task.Delay(500);
        }
    }

    IEnumerator AdjustContainerScale()
    {
        while (true)
        {
            var nextScale = Vector3.one  / currentMaxSize;
            boxContainer.transform.localScale =
                Vector3.Lerp(boxContainer.transform.localScale, nextScale, Time.deltaTime * 10);
            yield return null;
        }
    }
}